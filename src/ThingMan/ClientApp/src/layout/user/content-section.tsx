import React from "react";
import {Box} from "@mui/material";
import {Outlet} from "react-router-dom";

const ContentSection = () => {
    return (
        <Box component="main" sx={{width: "100%", py: 2, px: 4}}>
            <Box sx={(theme) => ({...theme.mixins.toolbar})}/>
            <Outlet/>
        </Box>
    );
};

export default ContentSection;
