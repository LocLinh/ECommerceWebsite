import jwt_decode from "jwt-decode";
import claimTypes from "claimtypes";

const initialUser = {
    userName : "",
    firstName : "",
    lastName : "",
    role : "",
}

function DecodeToken(token) {
    if (token === undefined) {
        return initialUser;
    }
    try {
        var decoded = jwt_decode(token);
        var user = {
            userName : decoded[claimTypes.nameIdentifier],
            firstName : decoded[claimTypes.surname],
            lastName : decoded[claimTypes.givenName],
            role : decoded[claimTypes.microsoft.role]
        }
    } catch {
        user = initialUser;
    }
    return user;
}

export { DecodeToken, initialUser };
