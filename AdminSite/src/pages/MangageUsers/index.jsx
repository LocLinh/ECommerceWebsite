import React, { useState, useEffect, Fragment, useRef } from "react";
import UserApi from "../../api/UserApi";
import TableData from "../../components/TableData";

const columns = [
    { field: "userName", headerName: "Username", flex: 1 },
    { field: "firstName", headerName: "FirstName", flex: 1 },
    { field: "lastName", headerName: "LastName", flex: 1 },
    { field: "role", headerName: "Role", flex: 1 },
];

const ManageUsers = () => {
    const [users, setUsers] = useState([]);
    useEffect(() => {
        UserApi.GetAll()
            .then((response) => {
                setUsers(response ? response : []);
            })
            .catch((error) => {
                console.log("error ", error)
            });
    }, []);

    return (
        <Fragment>
            <TableData rows={users} columns={columns}></TableData>
        </Fragment>
    );
};

function GetFullName(params) {
    return `${params.row.firstName || ""} ${params.row.lastName || ""}`;
}

export default ManageUsers;
