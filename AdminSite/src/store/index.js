import { configureStore } from "@reduxjs/toolkit";
import userReducer from "../pages/Login/UserSlide";

const rootReducer = {
    user: userReducer,
};

const store = configureStore({
    reducer: rootReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: false,
        }),
});

export default store;
