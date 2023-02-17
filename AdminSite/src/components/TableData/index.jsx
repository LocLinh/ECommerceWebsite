import PropTypes from "prop-types";
import Table from "react-bootstrap/Table";
import { Fragment } from "react";

const TableData = ({ columns, rows, IdCol=true }) => {
    return (
        <Fragment>
            <Table responsive>
                <thead>
                    <tr>
                        {IdCol && <th>#</th>}
                        {columns.map((header, index) => (
                            <th key={index}>{header.headerName}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {rows.map((user, index) => {
                        return (
                            <tr key={index}>
                                {IdCol && <td>{index + 1}</td>}
                                {columns.map((row, index) => (
                                    row.renderCell ? <td key={index}>{row.renderCell}</td> : <td key={index}>{user[row.field]}</td>
                                ))}
                            </tr>
                        );
                    })}
                </tbody>
            </Table>
        </Fragment>
    );
};

TableData.prototype = {
    columns: PropTypes.array,
    rows: PropTypes.array,
    IdCol: PropTypes.bool
};

export default TableData;
