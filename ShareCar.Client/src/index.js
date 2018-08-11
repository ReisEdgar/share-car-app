import React from "react";
import ReactDOM from "react-dom";
import { Route, Switch } from "react-router-dom";
import { Router } from "react-router";
import history from "./helpers/history";
import Layout from "./components/common/Layout";
import Login from "./components/Login";
import MyProfile from "./components/MyProfile";
import RoleSelection from "./components/RoleSelection";
import Driver from "./components/Driver";
import Passenger from "./components/Passenger";
import UserProfile from "./components/UserProfile";
import MapComponent from "./components/MapComponent";
import Rides from "./components/Rides";
import NewRideForm from "./components/NewRideForm";
import RideRequestForm from "./components/RideRequestForm";
import WinnerBoard from "./components/WinnerBoard";
import { Provider as AlertProvider } from "react-alert";
import AlertTemplate from "react-alert-template-basic";
import test from "./components/TestMap";

import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
//
const options = {
  position: "bottom center",
  timeout: 3000,
  offset: "30px",
  transition: "fade",
  type: "success"
};

ReactDOM.render(
  <Router history={history}>
    <Switch>
      <Route path="/login" component={Login} />
      <Layout>
        <Route exact path="/" component={RoleSelection} />
        <AlertProvider template={AlertTemplate} {...options}>

          <Route path="/test" component={test} />


          <Route path="/driveris" component={Driver} />
          <Route path="/passenger" component={Passenger} />
          <Route
            path="/:role(driver|passenger)/profile"
            component={UserProfile}
          />
          <Route path="/:role(driver|passenger)/test" component={test} />
          <Route path="/:role(driver|passenger)/map" component={MapComponent} />
          <Route path="/:role(driver|passenger)/rides" component={Rides} />
          <Route
            path="/:role(driver|passenger)/newRideForm"
            component={NewRideForm}
          />
          <Route
            path="/:role(driver|passenger)/rideRequest"
            component={RideRequestForm}
          />
          <Route path="/winnerBoard" component={WinnerBoard} />
        </AlertProvider>
      </Layout>
    </Switch>
  </Router>,
  document.getElementById("root")
);
