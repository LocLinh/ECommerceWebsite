import ProductApi from "../../api/ProductApi";
import { useEffect, useState, Fragment } from "react";
import TableData from "../../components/TableData";
import PaginationComponent from "../../components/Pagination";

const columns = [
    { field: "id", headerName: "ID" },
    { field: "name", headerName: "Category Name" },
    { field: "description", headerName: "Description" },
    { field: "categoryName", headerName: "Category Name" },
    { field: "price", headerName: "Price" },
    { field: "discountPercent", headerName: "Discount" },
    { field: "createdDate", headerName: "createdDate" },
    { field: "updatedDate", headerName: "updatedDate" }
];


function PrintHello() {
    return ( <div>hello</div> );
}

const MangageProducts = () => {
    const [productList, setProductList] = useState([]);
    const [pageSize, setPageSize] = useState(5);
    const [pageNumber, setPageNumber] = useState(1);

    useEffect(() => {
        ProductApi.GetByPage(pageNumber, pageSize)
            .then(
                (data) => {
                    setProductList(data)})
            .catch((error) => console.log(error));
    }, [pageNumber]);

    return (
        <Fragment>
            <TableData
                rows={productList}
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
}
export default MangageProducts;