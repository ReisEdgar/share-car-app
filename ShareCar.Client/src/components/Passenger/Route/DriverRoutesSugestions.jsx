import * as React from "react";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import Typography from "@material-ui/core/Typography";
import Phone from "@material-ui/icons/Phone";
import Button from "@material-ui/core/Button";

import RidesOfDriver from "../Ride/RidesOfDriver";

import "./../../../styles/genericStyles.css";
import "./../../../styles/driversRidesList.css";

export const DriverRoutesSugestions = (props) => (
    <Grid container justify="center" item xs={10}>
        <Card>
            {props.rides.map((driver, i) => (
            <Grid
                className="driver-button-container"
                item xs={12}
                key={i}
            >
                <Grid 
                    container 
                    alignItems="center" 
                    justify="center" 
                    className="names-and-phones" 
                    item xs={12}
                >
                    <Grid container className="driver-name" item xs={12}>
                        <Typography variant="caption">Driver </Typography>
                        <Typography variant="body1">
                            {driver.driverFirstName} {driver.driverLastName}
                        </Typography>
                    </Grid>
                    <Grid className="call" item xs={12}>
                        <Phone />
                        <Typography variant="body1">
                        {driver.driverPhone}
                        </Typography>
                    </Grid>
                </Grid>
                <Button
                    color="primary"
                    variant="contained"
                    style={{ "backgroundColor": "#007bff" }}
                    onClick={driver => props.showRidesOfDriver(driver)}
                >
                    View Time
                </Button>{" "}
                <Button
                    color="secondary"
                    variant="contained"
                    onClick={() => props.handleCloseDriver()}
                >
                    Close
                </Button>{" "}
            </Grid>
            ))}
            {props.showRides ? (
                <RidesOfDriver
                    rides={props.rides}
                    driver={props.driverEmail}
                    pickUpPoints={props.pickUpPoints}
                    className="date-display"
                />
            ) : (
                <div />
            )}
            </Card>
    </Grid>
);