import {Box, CircularProgress} from "@mui/material";
import React, {FC} from "react";

const Loading: FC = () => {
    return (
        <Box
            sx={{
                position: "fixed",
                top: 0,
                left: 0,
                right: 0,
                bottom: 0,
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                zIndex: 9999,
            }}
        >
            <CircularProgress/>
        </Box>
    );
};

export default Loading;
