import { Outlet } from "react-router-dom";

function MinimalLayout(props) {
    return (
        <div className="app">
            {/* <main className="content">
                    {props.children ? props.children : <Outlet />}
                </main> */}
            <Outlet />
        </div>
    );
}

export default MinimalLayout;
