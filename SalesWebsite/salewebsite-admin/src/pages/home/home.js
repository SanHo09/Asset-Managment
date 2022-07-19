import { Routes, Route, Link} from 'react-router-dom'


import 'react-notifications/lib/notifications.css';
import '~/styles/Dashboard.css'
import DefaultLayout from '~/Layout/defaultLayout';
import {publicRoutes} from '~/routers/index'

function Home() {
    return ( 
      <>
        {publicRoutes.map((route, index) => {
          const Page = route.component;
          console.log(route.path);
          return <Route  
                key={index} 
                path={route.path} 
                element={<DefaultLayout><Page /></DefaultLayout>} />
        })}
      </>
    );
}

export default Home;