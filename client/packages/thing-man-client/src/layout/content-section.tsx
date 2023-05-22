import { Container, styled } from "@mui/material";
import React, { FC } from "react";
import { Outlet } from "react-router-dom";

const classes = {
  headerSpace: `content-section-header-space`,
};
const Root = styled("div")(({ theme }) => ({
  [`& .${classes.headerSpace}`]: {
    ...theme.mixins.toolbar,
  },
}));

interface Props {
  loading: boolean;
}

const ContentSection: FC<Props> = ({ loading }) => {
  return (
    <Root>
      <Container maxWidth="xl" sx={{ pt: 4 }}>
        <div className={classes.headerSpace} />
        <Outlet />
      </Container>
    </Root>
  );
};

export default ContentSection;
