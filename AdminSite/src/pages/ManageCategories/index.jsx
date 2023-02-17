import { useEffect, useState, Fragment } from "react";
import CategoryApi from "../../api/CategoryApi";
import TableData from "../../components/TableData";
import PaginationComponent from "../../components/Pagination";

const columns = [
    { field: "id", headerName: "ID" },
    { field: "name", headerName: "Category Name" },
    { field: "description", headerName: "Description" },
    { field: "action", headerName: "Action", renderCell: <PrintHello /> },
];

function PrintHello() {
    return ( <div>hello</div> );
}


const ManageCategories = () => {
    const [categoryList, setCategoryList] = useState([]);
    const [pageSize, setPageSize] = useState(5);
    const [pageNumber, setPageNumber] = useState(1);

    useEffect(() => {
        CategoryApi.GetByPage(pageNumber, pageSize)
            .then((data) => setCategoryList(data))
            .catch((error) => console.log(error));
    }, [pageNumber]);
    return (
        <Fragment>
            <TableData
                rows={categoryList}
                columns={columns}
                IdCol={false}
            ></TableData>
            <PaginationComponent
                itemsCount={23}
                itemsPerPage={pageSize}
                currentPage={pageNumber}
                setCurrentPage={setPageNumber}
            ></PaginationComponent>
        </Fragment>
    );
};
export default ManageCategories;
