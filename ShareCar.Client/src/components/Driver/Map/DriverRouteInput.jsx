import * as React from "react";
import Button from "@material-ui/core/Button";
import ImportExport from "@material-ui/icons/ImportExport";

import { AddressInput } from "../../common/AddressInput";
import { OfficeAddresses } from "../../../utils/AddressData";
import { fromAlgoliaAddress } from "../../../utils/addressUtils";

import "../../../styles/testmap.css";
import SimpleMenu from "../../common/SimpleMenu";

class DriverRouteInputInner extends React.Component {

    render() {
        return (
            <div className="map-input-selection">
                {this.props.routePoints.map((element, index) => (
                    <AddressInput
                        className="driver-route-input"
                        key={index}
                        index={index}
                        deletable={index !== this.props.routePoints.length - 1}
                        removeRoutePoint={id => { this.props.removeRoutePoint(id) }}
                        onChange={(suggestion, index) => this.props.changeRoutePoint(fromAlgoliaAddress(suggestion), index)}
                        ref={this.props.innerRef}
                    />
                ))}

                <Button
                    variant="contained"
                    className="select-office-menu"
                    onClick={() => {
                        this.props.changeDirection();
                    }}
                    aria-haspopup="true"
                >
                    <ImportExport fontSize="medium" />
                </Button>
                <SimpleMenu
                    handleSelection={office => {
                        this.props.changeRoutePoint(office, -1);
                    }}
                />

            </div>
        );
    }
}

export const DriverRouteInput = React.forwardRef((props, ref) => <DriverRouteInputInner {...props} innerRef={ref} />);