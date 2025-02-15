namespace PlatformIntegration;

public partial class SensorsPage : ContentPage
{
	public SensorsPage()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		
    }

    #region Accelerometer
    private void AccelSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleAccelerometer(Accelerometer.Default);
    }

    //<toggle_accelerometer>
    public void ToggleAccelerometer(IAccelerometer accelerometer)
    {
        if (accelerometer.IsSupported)
        {
            if (!accelerometer.IsMonitoring)
            {
                // Turn on accelerometer
                accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                accelerometer.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                accelerometer.Stop();
                accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            }
        }    
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        // Update UI Label with accelerometer state
        AccelLabel.TextColor = Colors.Green;
        AccelLabel.Text = $"Accel: {e.Reading}";
    }
    //</toggle_accelerometer>
    #endregion

    #region Barometer
    private void BarometerSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleBarometer(Barometer.Default);
    }

    //<toggle_barometer>
    public void ToggleBarometer(IBarometer barometer)
    {
        if (barometer.IsSupported)
        {
            if (!barometer.IsMonitoring)
            {
                // Turn on accelerometer
                barometer.ReadingChanged += Barometer_ReadingChanged;
                barometer.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                barometer.Stop();
                barometer.ReadingChanged -= Barometer_ReadingChanged;
            }
        }
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
        // Update UI Label with barometer state
        BarometerLabel.TextColor = Colors.Green;
        BarometerLabel.Text = $"Barometer: {e.Reading}";
    }
    //</toggle_barometer>
    #endregion

    #region Compass
    private void CompassSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleCompass(Compass.Default);
    }

    //<toggle_compass>
    private void ToggleCompass(ICompass compass)
    {
        if (compass.IsSupported)
        {
            if (!compass.IsMonitoring)
            {
                // Turn on compass
                compass.ReadingChanged += Compass_ReadingChanged;
                compass.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                compass.Stop();
                compass.ReadingChanged -= Compass_ReadingChanged;
            }
        }
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        // Update UI Label with compass state
        CompassLabel.TextColor = Colors.Green;
        CompassLabel.Text = $"Compass: {e.Reading}";
    }
    //</toggle_compass>
    #endregion

    #region Gyroscope
    private void GyroscopeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleGyroscope(Gyroscope.Default);
    }

    //<toggle_gyroscope>
    private void ToggleGyroscope(IGyroscope gyroscope)
    {
        if (gyroscope.IsSupported)
        {
            if (!gyroscope.IsMonitoring)
            {
                // Turn on compass
                gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                gyroscope.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                gyroscope.Stop();
                gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
            }
        }
    }

    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        // Update UI Label with gyroscope state
        GyroscopeLabel.TextColor = Colors.Green;
        GyroscopeLabel.Text = $"Gyroscope: {e.Reading}";
    }
    //</toggle_gyroscope>
    #endregion

    #region Magnetometer
    private void MagnetometerSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleMagnetometer(Magnetometer.Default);
    }

    //<toggle_magnetometer>
    private void ToggleMagnetometer(IMagnetometer magnetometer)
    {
        if (magnetometer.IsSupported)
        {
            if (!magnetometer.IsMonitoring)
            {
                // Turn on compass
                magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
                magnetometer.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                magnetometer.Stop();
                magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
            }
        }
    }

    private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {
        // Update UI Label with magnetometer state
        MagnetometerLabel.TextColor = Colors.Green;
        MagnetometerLabel.Text = $"Magnetometer: {e.Reading}";
    }
    //</toggle_magnetometer>
    #endregion

    #region Orientation
    private void OrientationSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleOrientation(OrientationSensor.Default);
    }

    //<toggle_orientation>
    private void ToggleOrientation(IOrientationSensor orientation)
    {
        if (orientation.IsSupported)
        {
            if (!orientation.IsMonitoring)
            {
                // Turn on compass
                orientation.ReadingChanged += Orientation_ReadingChanged;
                orientation.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                orientation.Stop();
                orientation.ReadingChanged -= Orientation_ReadingChanged;
            }
        }
    }

    private void Orientation_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
    {
        // Update UI Label with orientation state
        OrientationLabel.TextColor = Colors.Green;
        OrientationLabel.Text = $"Orientation: {e.Reading}";
    }
    //</toggle_orientation>
    #endregion

    #region Shake
    private void ShakeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        ToggleShake(Accelerometer.Default);
    }

    //<toggle_shake>
    private void ToggleShake(IAccelerometer accelerometer)
    {
        if (accelerometer.IsSupported)
        {
            if (!accelerometer.IsMonitoring)
            {
                // Turn on compass
                accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
                accelerometer.Start(SensorSpeed.Game);
            }
            else
            {
                // Turn off compass
                accelerometer.Stop();
                accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            }
        }
    }

    private void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
        // Update UI Label with a "shaked detected" notice, in a randomized color
        ShakeLabel.TextColor = new Color(Random.Shared.Next(256), Random.Shared.Next(256), Random.Shared.Next(256));
        ShakeLabel.Text = $"Shake detected";
    }
    //</toggle_shake>
    #endregion

    #region Geocoding
    private async void Geocoding_Clicked(object sender, EventArgs e)
    {
        //<geocoding_location>
        string address = "Microsoft Building 25 Redmond WA USA";
        IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

        Location location = locations?.FirstOrDefault();

        if (location != null)
            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //</geocoding_location>
    }

    //<geocoding_reverse>
    private async Task<string> GetGeocodeReverseData(double latitude = 47.673988, double longitude = -122.121513)
    {
        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

        Placemark placemark = placemarks?.FirstOrDefault();

        if (placemark != null)
        {
            return
                $"AdminArea:       {placemark.AdminArea}\n" +
                $"CountryCode:     {placemark.CountryCode}\n" +
                $"CountryName:     {placemark.CountryName}\n" +
                $"FeatureName:     {placemark.FeatureName}\n" +
                $"Locality:        {placemark.Locality}\n" +
                $"PostalCode:      {placemark.PostalCode}\n" +
                $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                $"SubLocality:     {placemark.SubLocality}\n" +
                $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                $"Thoroughfare:    {placemark.Thoroughfare}\n";

        }

        return "";
    }
    //</geocoding_reverse>
    #endregion

    #region Geolocation

    private async void Geolocation1_Clicked(object sender, EventArgs e)
    {
        LastLocationLabel.Text = await GetCachedLocation();
    }

    //<geolocation_cached>
    public async Task<string> GetCachedLocation()
    {
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
                return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }

        return "None";
    }
    //</geolocation_cached>

    //<geolocation_get>
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
    //</geolocation_get>

    //<geolocation_ismock>
    public async Task CheckMock()
    {
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium);
        Location location = await Geolocation.Default.GetLocationAsync(request);

        if (location != null && location.IsFromMockProvider)
        {
            // location is from a mock provider
        }
    }
    //</geolocation_ismock>

    public void CheckDistance()
    {
        //<geolocation_distance>
        Location boston = new Location(42.358056, -71.063611);
        Location sanFrancisco = new Location(37.783333, -122.416667);

        double miles = Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Miles);
        //</geolocation_distance>
    }
    #endregion
}