window.Shiny = {
    accelerometer: null,

    startSensor: function (ref) {
        this.accelerometer = new Accelerometer({ referenceFrame: 'device' });
        accelerometer.addEventListener('error', e => {
            ref.invokeMethodAsync('OnError', e.error.name);
        });
        this.accelerometer.addEventListener('reading', e => ref.invokeMethodAsync('OnReading', e));
        this.accelerometer.start();
    },

    stopSensor: function (sensor) {
        this.accelerometer.stop();
    }
};