import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
    Button,
    FormHelperText,
    Grid,
    IconButton,
    InputAdornment,
    InputLabel,
    OutlinedInput,
    Stack,
} from "@mui/material";
import { ThreeDots } from 'react-loading-icons'
import { DecodeToken } from "../../utils/DecodeToken";
import { getToken } from "../../api/ApiClient";

// third party
import * as Yup from "yup";
import { Formik } from "formik";

// assets
import VisibilityOutlinedIcon from "@mui/icons-material/VisibilityOutlined";
import VisibilityOffOutlinedIcon from "@mui/icons-material/VisibilityOffOutlined";
import { useSelector, useDispatch } from "react-redux";
import { fetchAuth } from "./UserSlide";

const initialValues = {
    userName: "",
    password: "",
}

const yupValidationSchema = Yup.object().shape({
    userName: Yup.string()
        .max(255)
        .required("Username is required"),
    password: Yup.string()
        .max(255)
        .required("Password is required"),
})

const AuthLogin = () => {
    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const handleClickShowPassword = () => {setShowPassword(!showPassword);};
    const loading = useSelector((state) => state.user.loading)

    return (
        <>
            <Formik
                initialValues={initialValues}
                validationSchema={yupValidationSchema}
                onSubmit={async (
                    values,
                    { setErrors, setStatus, setSubmitting }
                ) => {
                    dispatch(fetchAuth(values))
                        .then(() => {
                            if (DecodeToken(getToken()).role == "Admin"){
                                navigate("/");
                                setStatus({ submit: "Successfully log in" });
                                setStatus({ success: true });
                                setSubmitting(false);
                            }
                            else{
                                setErrors({ submit: "This user is not an admin." });
                                setStatus({ success: false });
                                setSubmitting(false);
                            }
                        })
                        .catch((error) => {
                            console.log("🚀 ~ file: AuthLogin.jsx:71 ~ AuthLogin ~ error", error)
                            setErrors({ submit: "Wrong username or password" });
                            setStatus({ success: false });
                            setSubmitting(false);
                        });
                }}
            >
                {({
                    errors,
                    handleBlur,
                    handleChange,
                    handleSubmit,
                    isSubmitting,
                    touched,
                    values,
                }) => (
                    <form noValidate onSubmit={handleSubmit}>
                        <Grid container spacing={3}>
                            <Grid item xs={12}>
                                <Stack spacing={1}>
                                    <InputLabel htmlFor="username-login">
                                        Username
                                    </InputLabel>
                                    <OutlinedInput
                                        id="username-login"
                                        type="text"
                                        value={values.userName}
                                        name="userName"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        placeholder="Enter username"
                                        fullWidth
                                        error={Boolean(touched.userName && errors.userName)}
                                    />
                                    {touched.userName && errors.userName && (
                                        <FormHelperText
                                            error
                                            id="standard-weight-helper-text-username-login"
                                        >
                                            {errors.userName}
                                        </FormHelperText>
                                    )}
                                </Stack>
                            </Grid>
                            <Grid item xs={12}>
                                <Stack spacing={1}>
                                    <InputLabel htmlFor="password-login">
                                        Password
                                    </InputLabel>
                                    <OutlinedInput
                                        fullWidth
                                        error={Boolean(
                                            touched.password && errors.password
                                        )}
                                        id="-password-login"
                                        type={showPassword ? "text" : "password"}
                                        value={values.password}
                                        name="password"
                                        onBlur={handleBlur}
                                        onChange={handleChange}
                                        endAdornment={
                                            <InputAdornment position="end">
                                                <IconButton
                                                    aria-label="toggle password visibility"
                                                    onClick={
                                                        handleClickShowPassword
                                                    }
                                                    edge="end"
                                                    size="large"
                                                >
                                                    {showPassword ? (
                                                        <VisibilityOutlinedIcon />
                                                    ) : (
                                                        <VisibilityOffOutlinedIcon />
                                                    )}
                                                </IconButton>
                                            </InputAdornment>
                                        }
                                        placeholder="Enter password"
                                    />
                                    {touched.password && errors.password && (
                                        <FormHelperText
                                            error
                                            id="standard-weight-helper-text-password-login"
                                        >
                                            {errors.password}
                                        </FormHelperText>
                                    )}
                                </Stack>
                            </Grid>

                            {errors.submit && (
                                <Grid item xs={12}>
                                    <FormHelperText error>
                                        {errors.submit}
                                    </FormHelperText>
                                </Grid>
                            )}
                            <Grid item xs={12}>
                                <Button
                                    disableElevation
                                    disabled={isSubmitting}
                                    fullWidth
                                    size="large"
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                >
                                    {loading ? <ThreeDots height={'1.5em'} /> : "Login"}
                                </Button>
                            </Grid>
                        </Grid>
                    </form>
                )}
            </Formik>
        </>
    );
};

export default AuthLogin;
