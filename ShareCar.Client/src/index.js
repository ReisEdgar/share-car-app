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
import "bootstrap/dist/css/bootstrap.min.css";
import "./src/index.css";

ReactDOM.render(
  <Router history={history}>
    <Switch>
      <Route path="/login" component={Login} />
      <Layout>
        <Route exact path="/" component={RoleSelection} />
        <Route path="/driver" component={Driver} />
        <Route path="/passenger" component={Passenger} />
        <Route path="/profile" component={UserProfile} />
      </Layout>
    </Switch>
  </Router>,
  document.getElementById("root")
);
