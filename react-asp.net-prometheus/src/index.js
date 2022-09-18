import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';

//Metrics dependencies
import reportWebVitals from './reportWebVitals';
import { getFCP, getTTFB } from 'web-vitals';
import ttiPolyfill from 'tti-polyfill';
import sendMetrics from './SendMetrics';

//ttiPolyfill Snippet
if ('PerformanceLongTaskTiming' in window) {
    var g = window.__tti = { e: [] };
    g.o = new PerformanceObserver(function (l) { g.e = g.e.concat(l.getEntries()) });
    g.o.observe({ entryTypes: ['longtask'] })
}

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <BrowserRouter basename={baseUrl}>
        <App />
    </BrowserRouter>);

setTimeout(function () {
    //Metrics
    getFCP((fcp) => {
        sendMetrics('ReactApp_FCP', fcp.value.toString());
    });
    getTTFB((ttfb) => {
        sendMetrics('ReactApp_TTFB', ttfb.value.toString());
    });

    ttiPolyfill.getFirstConsistentlyInteractive().then((tti) => {
        sendMetrics('ReactApp_TTI', tti.toString());
    });

    const loadTime = window.performance.timing.domContentLoadedEventEnd - window.performance.timing.navigationStart;
    sendMetrics('ReactApp_Load_Time', loadTime.toString());

    const domainLookup = window.performance.timing.domainLookupEnd - window.performance.timing.domainLookupStart;
    sendMetrics('ReactApp_DNSLookup', domainLookup.toString());
}, 0);

serviceWorkerRegistration.unregister();

reportWebVitals(console.log);
