import * as React from "react";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import Card from "@material-ui/core/Card";
import Button from "@material-ui/core/Button";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import "../../../styles/genericStyles.css";
import MapComponent from "../../Maps/MapComponent";
export default class RidePassengerCard extends React.Component {
    state = {
        show: false
    }
    render() {
        return (
            <div>
                <Card className="generic-card passenger-card">
                    <CardContent>
                        <Typography variant="title">
                            {this.props.passenger.firstName + " " + this.props.passenger.lastName}
                        </Typography>
                        <Typography variant="p">Phone {this.props.passenger.phone}</Typography>
                        <CardActions>
                            <Button
                                onClick={() => { this.setState({ show: !this.state.show }) }}
                            >
                                Show on map
                    </Button>
                            </CardActions>
                </CardContent>
            </Card>
                    {this.state.show ?
                        <Card className="requestMap rides-card generic-card">
                            <Grid container justify="center">
                                <Grid item xs={12} zeroMinWidth>
                                    <MapComponent
                                        pickUpPoint={{ longitude: this.props.passenger.longitude, latitude: this.props.passenger.latitude }}
                                        route={this.props.passenger.route}
                                        index={this.props.index}
                                    />
                                </Grid>
                            </Grid>
                        </Card>
                        : <div></div>}
        
</div>
                );
                    }
}