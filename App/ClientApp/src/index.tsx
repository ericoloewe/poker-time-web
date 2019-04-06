import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Router } from './pages/shared/router';
import registerServiceWorker from './workers/register-service-worker';
import './index.scss';
import { Loader } from './components/loader';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl || undefined}>
    <React.Suspense fallback={<Loader />}>
      <Router />
    </React.Suspense>
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
