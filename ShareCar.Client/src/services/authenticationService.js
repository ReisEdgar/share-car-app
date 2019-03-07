// @flow
import api from '../helpers/axiosHelper';

class AuthenticationService {

    loginWithFacebook = (accessToken: AccessToken, success: () => void, unauthorized: () => void) => {
        api.post('authentication/FacebookLogin', {
            accessToken: accessToken
        })
        .then((response) => {
            console.log("_________________________");
            console.log(response);
            if (response.status === 200)
            success();
        })
        .catch((error) => {
            console.log("_________________________");
            console.log(error);     
                  console.log("_________________________");
            console.log(error.response);
            if(error.response.status === 401){
                unauthorized();
            } else{
                console.error(error);
            }
        });
    }

    loginWithGoogle = (profileObj: ProfileObj, success: () => void, unauthorized: () => void) => {
        api.post('authentication/GoogleLogin', profileObj)
        .then((response) => {
            if (response.status === 200)
            success();
        })
        .catch((error) => {
            if(error.response.status === 401){
                unauthorized();
            } else{
                console.error(error);
            }
        });
    }


    logout = (callback: () => void) => {
        api.post('authentication/logout')
        .then((response) => {
            if (response.status === 200)
                callback();
        })
        .catch(function (error) {
            console.error(error);
        });
    }
}

export default AuthenticationService;