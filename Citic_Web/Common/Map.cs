using System;
using System.Collections;
using System.Reflection;

namespace Citic_Web
{
    public enum MapStyle
    {
        Road,
        Aerial,
        Hybrid
    }

    public enum MapLanguageVersion
    {
        Chinese,
        UnitedStates
    }

    /// <summary>
    /// A map displayed on the screen.
    /// </summary>
    public class Map
    {
        private int width, height;
        private int zoomLevel;
        /// <summary>
        /// The X-coordinate of the center of the map, in pixels, in world coordinates (at the current zoom level).
        /// </summary>
        private int x;
        /// <summary>
        /// The Y-coordinate of the center of the map, in pixels, in world coordinates (at the current zoom level).
        /// </summary>
        private int y;
        /// <summary>
        /// The latitude of the center of the map.
        /// </summary>
        private double latitude;
        /// <summary>
        /// The longitude of the center of the map.
        /// </summary>
        private double longitude;
        private MapStyle mapStyle;

        private const int earthRadius = 6378137;
        private const int buffer = 0/*100*/;
        private const double offsetMeters = 20971520;
        private const double baseMetersPerPixel = 163840;

        private const double MinLatitude = -85.05112878;
        private const double MaxLatitude = 85.05112878;
        private const double MinLongitude = -180;
        private const double MaxLongitude = 180;

        public Map()
        {

        }

        /// <summary>
        /// Minimum allowed zoom level
        /// </summary>
        public int MinimumZoom
        {
            get { return 3; }
        }

        /// <summary>
        /// Maximum allowed zoom level
        /// </summary>
        public int MaximumZoom
        {
            get { return 19; }
        }


        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude
        {
            get
            {
                if (double.IsNaN(latitude))
                {

                    // We have panned, so we must recalculate the latitude.
                    latitude = YToLatitudeAtZoom(Y, zoomLevel);
                }
                return latitude;
            }
            set
            {
                latitude = value;
                y = LatitudeToYAtZoom(latitude, zoomLevel);

            }
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude
        {
            get
            {
                if (double.IsNaN(longitude))
                {
                    // We have panned, so we must recalculate the longitude.
                    longitude = XToLongitudeAtZoom(X, zoomLevel);
                }
                return longitude;
            }
            set
            {
                longitude = value;
                x = LongitudeToXAtZoom(longitude, zoomLevel);
            }
        }


        /// <summary>
        /// The X-coordinate of the center of the map, in pixels,
        /// in world coordinates (at the current zoom level).
        /// </summary>
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                // We don't bother recalculating the longitude until asked for.
                // So right now, we just invalidate it.
                longitude = double.NaN;
            }
        }

        /// <summary>
        /// The Y-coordinate of the center of the map, in pixels,
        /// in world coordinates (at the current zoom level).
        /// </summary>
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                // We don't bother recalculating the latitude until asked for.
                // So right now, we just invalidate it.
                latitude = double.NaN;
            }
        }

        /// <summary>
        /// The style of map (road, aerial, or hybrid).
        /// </summary>
        public MapStyle MapStyle
        {
            get { return mapStyle; }
            set { mapStyle = value; }
        }

        private MapLanguageVersion languageVersion;
        /// <summary>
        /// The version of map (chinese,us).
        /// </summary>
        public MapLanguageVersion LanguageVersion
        {
            get { return languageVersion; }
            set { languageVersion = value; }
        }

        /// <summary>
        /// The current zoom level.
        /// </summary>
        public int ZoomLevel
        {
            get { return zoomLevel; }
            set
            {
                // Make sure we have a valid lat/long at the old zoom level
                // before we change the zoom level.
                double lon = Longitude;
                double lat = Latitude;
                zoomLevel = value;
                //x = LongitudeToXAtZoom(lon, zoomLevel);
                //y = LatitudeToYAtZoom(lat, zoomLevel);
            }
        }

        /// <summary>
        /// Zooms the in.
        /// </summary>
        public void ZoomIn()
        {
            if (ZoomLevel < MaximumZoom)
            {
                ZoomLevel = ZoomLevel + 1;
                x = 2 * X;
                y = 2 * Y;
            }
        }

        /// <summary>
        /// Zooms the out.
        /// </summary>
        public void ZoomOut()
        {
            if (ZoomLevel > MinimumZoom)
            {
                ZoomLevel = ZoomLevel - 1;
                x = X / 2;
                y = Y / 2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="zoomLevel">The zoom level.</param>
        /// <param name="mapStyle">The map style.</param>
        /// <param name="mlv">The MLV.</param>
        public Map(
            int width,
            int height,
            double latitude,
            double longitude,
            int zoomLevel,
            MapStyle mapStyle,
            MapLanguageVersion mlv)
        {
            this.width = width;
            this.height = height;
            this.zoomLevel = zoomLevel;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.MapStyle = mapStyle;
            this.LanguageVersion = mlv;
        }

        /// <summary>
        /// Lats the long to pixel XY.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="levelOfDetail">The level of detail.</param>
        /// <param name="pixelX">The pixel X.</param>
        /// <param name="pixelY">The pixel Y.</param>
        public static void LatLongToPixelXY(double latitude, double longitude, int levelOfDetail,
            out int pixelX, out int pixelY)
        {
            latitude = Clip(latitude, MinLatitude, MaxLatitude);
            longitude = Clip(longitude, MinLongitude, MaxLongitude);

            double x = (longitude + 180) / 360;
            double sinLatitude = Math.Sin(latitude * Math.PI / 180);
            double y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

            uint mapSize = MapSize(levelOfDetail);
            pixelX = (int)Clip(x * mapSize + 0.5, 0, mapSize - 1);
            pixelY = (int)Clip(y * mapSize + 0.5, 0, mapSize - 1);
        }


        /// <summary>
        /// Lats the long to tile XY.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="levelOfDetail">The level of detail.</param>
        /// <param name="tileX">The tile X.</param>
        /// <param name="tileY">The tile Y.</param>
        public static void LatLongToTileXY(double latitude, double longitude, int levelOfDetail, out int tileX, out int tileY)
        {
            int pixelX = 0;
            int pixelY = 0;

            LatLongToPixelXY(latitude, longitude, levelOfDetail, out pixelX, out pixelY);
            PixelXYToTileXY(pixelX, pixelY, out tileX, out tileY);
        }

        /// <summary>
        /// Pixels the XY to tile XY.
        /// </summary>
        /// <param name="pixelX">The pixel X.</param>
        /// <param name="pixelY">The pixel Y.</param>
        /// <param name="tileX">The tile X.</param>
        /// <param name="tileY">The tile Y.</param>
        public static void PixelXYToTileXY(int pixelX, int pixelY, out int tileX, out int tileY)
        {
            tileX = pixelX / 256;
            tileY = pixelY / 256;
        }


        /// <summary>
        /// Maps the size.
        /// </summary>
        /// <param name="levelOfDetail">The level of detail.</param>
        /// <returns></returns>
        public static uint MapSize(int levelOfDetail)
        {
            return (uint)256 << levelOfDetail;
        }

        /// <summary>
        /// Clips the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <returns></returns>
        private static double Clip(double n, double minValue, double maxValue)
        {
            return Math.Min(Math.Max(n, minValue), maxValue);
        }

        /// <summary>
        /// Meterses the per pixel.
        /// </summary>
        /// <param name="zl">The zl.</param>
        /// <returns></returns>
        private static double MetersPerPixel(int zl)
        {
            return baseMetersPerPixel / (1 << zl);
        }

        // modify by Nick
        //private int LongitudeToXAtZoom(double lon, int zl)
        //{
        //    double metersX = Map.earthRadius * DegToRad(lon);
        //    return (int)Math.Round((metersX + Map.offsetMeters) / MetersPerPixel(zl));
        //}


        //private int LatitudeToYAtZoom(double lat, int zl)
        //{
        //    double sinLat = Math.Sin(DegToRad(lat));
        //    double metersY = Map.earthRadius / 2 * Math.Log((1 + sinLat) / (1 - sinLat));
        //    return (int)Math.Round((Map.offsetMeters - metersY) / MetersPerPixel(zl));
        //}


        /// <summary>
        /// Ys to latitude at zoom.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="zl">The zl.</param>
        /// <returns></returns>
        private double YToLatitudeAtZoom(int y, int zl)
        {
            double metersY = Map.offsetMeters - y * MetersPerPixel(zl);
            return RadToDeg(Math.PI / 2 - 2 * Math.Atan(Math.Exp(-metersY / earthRadius)));
        }

        /// <summary>
        /// Xs to longitude at zoom.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="zl">The zl.</param>
        /// <returns></returns>
        private double XToLongitudeAtZoom(int x, int zl)
        {
            double metersX = x * MetersPerPixel(zl) - offsetMeters;
            return RadToDeg(metersX / earthRadius);
        }

        /// <summary>
        /// Longitudes to X at zoom.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="zl">The zl.</param>
        /// <returns></returns>
        private int LongitudeToXAtZoom(double longitude, int zl)
        {
            longitude = Clip(longitude, MinLongitude, MaxLongitude);

            double x = (longitude + 180) / 360;

            uint mapSize = MapSize(zl);
            return (int)Clip(x * mapSize + 0.5, 0, mapSize - 1);
        }


        /// <summary>
        /// Latitudes to Y at zoom.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="zl">The zl.</param>
        /// <returns></returns>
        private int LatitudeToYAtZoom(double latitude, int zl)
        {
            double sinLatitude = Math.Sin(latitude * Math.PI / 180);
            double y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

            uint mapSize = MapSize(zl);

            return (int)Clip(y * mapSize + 0.5, 0, mapSize - 1);
        }

        /// <summary>
        /// Degs to RAD.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        private static double DegToRad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// RADs to deg.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        private static double RadToDeg(double r)
        {
            return r * 180.0 / Math.PI;
        }

        public static double PixelXToLng(double pixelX, int zoom)
        {
            return pixelX * 360 / (256L << zoom) - 180;
        }

        public static double PixelYToLat(double pixelY, int zoom)
        {
            double y = 2 * Math.PI * (1 - pixelY / (128 << zoom));
            double z = Math.Pow(Math.E, y);
            double siny = (z - 1) / (z + 1);
            return Math.Asin(siny) * 180 / Math.PI;
        }
    }
}
