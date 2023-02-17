import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";

// layout
import MinimalLayout from "../layout/MinimalLayout";
import MainLayout from "../layout/MainLayout";
// component
import Dashboard from "../pages/Dashboard";
import ManageUsers from "../pages/MangageUsers";
import ManageCategories from "../pages/ManageCategories";
import MangageProducts from "../pages/ManageProducts";
import Report from "../pages/Report";
import Login from "../pages/Login";
import { useSelector } from "react-redux";
import ProtectedRoute from "./ProtectedRoute";

function MainRoutes() {
    return (
        <Fragment>
            <Routes>
                <Route path="/" element={<MainLayout />}>
                    <Route element={<ProtectedRoute />} >\
                        <Route index element={<Dashboard />}></Route>
                        <Route path="/manage-users" element={<ManageUsers />}></Route>
                        <Route path="/manage-categories" element={<ManageCategories />}></Route>
                        <Route path="/manage-products" element={<MangageProducts />}></Route>
                        <Route path="/report" element={<Report />}></Route>
                    </Route>
                </Route>
                <Route element={<MinimalLayout />}>
                    <Route path="/login" element={<Login />}></Route>
                </Route>
            </Routes>
        </Fragment>
    );
}

export default MainRoutes;