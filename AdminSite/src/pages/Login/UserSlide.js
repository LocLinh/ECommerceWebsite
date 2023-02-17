import AuthApi from "../../api/AuthApi";
import { DecodeToken, initialUser } from "../../utils/DecodeToken";
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import Cookies from "universal-cookie";
const cookies = new Cookies();

const userSlice = createSlice({
    name: "user",
    initialState: { loading: false, currentUser: initialUser },
    extraReducers: (builder) => {
        builder
            .addCase(fetchAuth.pending, (state, action) => {
                state.loading = true;
            })
            .addCase(fetchAuth.fulfilled, (state, action) => {
                state.loading = false;
                const loginUser = DecodeToken(action.payload);
                if (loginUser.role === "Admin") {
                    state.currentUser = loginUser;
                    cookies.set("Token", action.payload, {path: "/", expires: new Date(Date.now() + 1000*30*60)});
                }
            })
            .addCase(fetchAuth.rejected, (state, action) => {
                state.loading = false;
                state.currentUser = initialUser;
            });
    },
    reducers: {
        logout(state) {
            state.currentUser = initialUser;
            cookies.remove("Token");
        }
    }
});

export default userSlice.reducer;

export const fetchAuth = createAsyncThunk("users/fetchAuth", async (params) => {
    const res = await AuthApi.GetToken(params);
    return res;
});
