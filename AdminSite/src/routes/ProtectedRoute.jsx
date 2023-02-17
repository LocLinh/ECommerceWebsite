import { Navigate, Outlet } from "react-router-dom";
import { DecodeToken } from "../utils/DecodeToken";
import { getToken } from "../api/ApiClient";
const ProtectedRoute = () => {
    var userRole = DecodeToken(getToken()).role;

    return userRole !== "Admin" ? (
        <Navigate to='/login' replace />
    ) : (
        <Outlet />
    );
};

export default ProtectedRoute;
