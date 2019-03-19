import * as React from "react";
import SimpleMenu from "./SimpleMenu";
import AlgoliaPlaces from "algolia-places-react";
import Close from "@material-ui/icons/Close";

import "../../styles/genericStyles.css";

export const AddressInput = React.forwardRef((props, ref) => (
    <div className="form-group">
        
        <AlgoliaPlaces
            onChange={({ query, rawAnswer, suggestion, suggestionIndex }) => props.onChange(suggestion, props.index)}
            onClear={() => props.onChange(null)}
            ref={ref}
        />
        {
            props.deletable ?
                <Close onClick={() => { props.removeRoutePoint(props.index) }} />
                :
                <div></div>
        }
    </div>
));