import React from "react";
import {Box, Stack, Typography} from "@mui/material";

const CreateThingDefPage = () => {
    return (
        <Stack spacing={4} sx={{pt: 2}}>
            <Box alignItems="center" sx={{display: "flex"}}>
                <Box sx={{flexGrow: 1}}>
                    <Typography variant="h4" component="h1">
                        Create Thing Definition
                    </Typography>
                </Box>
            </Box>
        </Stack>
    );
};

export default CreateThingDefPage;
