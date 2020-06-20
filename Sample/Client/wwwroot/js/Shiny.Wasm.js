window.Shiny = {
    accelerometer: null,

    isFeatureAvailable: function (type) {
        return (type in window);
    },

    requestPermission: function (name, promise) {
        navigator
            .permissions
            .query(name)
            .then(function(x) {
                console.log('Permission Response', x);
                promise.invokeMethod('Accept', x.state);
            })
            .catch(function(e) {
                console.log('Permission Error', e);
                promise.invokeMethod('Reject', e);
            });
    },

    startSensor: function (ref) {
        try {
            this.accelerometer = new Accelerometer();
            accelerometer.addEventListener('error', e => {
                console.log(e);
                ref.invokeMethodAsync('OnError', e.error.name);
            });
            this.accelerometer.addEventListener('reading', e => ref.invokeMethodAsync('OnReading', e));
            this.accelerometer.start();
        }
        catch (e) {
            console.log('Failed to start', e);
        }
    },

    stopSensor: function (sensor) {
        this.accelerometer.stop();
    }
};