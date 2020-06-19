window.Shiny = {
    accelerometer: null,

    startSensor: function (ref, sensor) {
        this.accelerometer = new Accelerometer({ referenceFrame: 'device' });
        accelerometer.addEventListener('error', e => {
            ref.invokeMethodAsync('OnError', e.error.name);
        });
        accelerometer.addEventListener('reading', e => ref.invokeMethodAsync('OnReading', e));
        accelerometer.start();
    },

    stopSensor: function (sensor) {
        this.accelerometer.stop();
    }
};