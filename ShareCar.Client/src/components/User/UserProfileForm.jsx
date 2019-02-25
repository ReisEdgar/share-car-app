import * as React from "react";

import "../../styles/userProfile.css";
import { UserPoints } from "./UserPoints";
import { UserProfileFormField } from "./UserProfileFormField";

import "../../styles/userProfile.css";

export const UserProfileForm = (props) => (
    <div className="container-fluid">
        <div className="container profile-container">
          <button
            className="logout-button logout-text"
            onClick={() => props.onClick()}
          >
            Logout
          </button>
          <form className="profile-form col-sm-6">
            <img className="thumbnail" src={props.user.pictureUrl} />
            <UserProfileFormField 
                displayName="Your Email"
                disabled="true"
                name="email"
                type="email"
                value={props.user.email}
            />
            <UserProfileFormField 
                displayName="First Name"
                name="name"
                type="text"
                value={props.user.firstName}
                onChange={e => props.onNameChange(e)}
            />
            <UserProfileFormField 
                displayName="Last Name"
                name="surname"
                type="text"
                value={props.user.lastName}
                onChange={e => props.onSurnameChange(e)}
            />
            <UserProfileFormField 
                displayName="Phone Number"
                name="phone"
                type="text"
                value={props.user.phone}
                onChange={e => props.onPhoneChange(e)}
            />
            <UserProfileFormField 
                displayName="License Plate Number"
                name="license"
                type="text"
                value={props.user.licensePlate}
                onChange={e => props.onLicenseChange(e)}
            />
            <button
              onClick={e => props.onButtonClick(e)}
              className="btn btn-primary"
            >
              Save
            </button>
          </form>
          <UserPoints 
            pointCount={props.user.pointCount}
            role={props.role}
          />
        </div>
    </div>
);