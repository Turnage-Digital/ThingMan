import {RocketLaunch} from "@mui/icons-material";
import {Box, Button, Stack, Typography} from "@mui/material";
import React from "react";
import {useNavigate} from "react-router-dom";

const ThingDefsPage = () => {
    const navigate = useNavigate();

    const handleCreateNewThingDefClicked = () => {
        navigate("/thing-defs/create");
    };

    return (
        <Stack spacing={4} sx={{pt: 2}}>
            <Box alignItems="center" sx={{display: "flex"}}>
                <Box sx={{flexGrow: 1}}>
                    <Box sx={{flexGrow: 1}}>
                        <Typography variant="h4" component="h1">
                            Thing Definitions
                        </Typography>
                    </Box>
                </Box>
                <Button
                    variant="contained"
                    startIcon={<RocketLaunch/>}
                    onClick={handleCreateNewThingDefClicked}
                >
                    create thing definition
                </Button>
            </Box>
        </Stack>
    );
};

export default ThingDefsPage;
