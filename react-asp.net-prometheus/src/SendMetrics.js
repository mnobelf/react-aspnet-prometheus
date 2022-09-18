async function sendMetrics(metricsName, value) {
    try {
        const response = await fetch('https://localhost:7296/api/FrontEndMetrics', {
            method: 'POST',
            mode: 'cors',
            headers: new Headers({
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify({ name: metricsName, value: value }),
        });

        const result = await response.json();

        return result;
    } catch (error) {
        if (error instanceof Error) {
            console.log('error message: ', error.message);
            return error.message;
        } else {
            console.log('unexpected error: ', error);
            return 'An unexpected error occurred';
        }
    }
}

export default sendMetrics;