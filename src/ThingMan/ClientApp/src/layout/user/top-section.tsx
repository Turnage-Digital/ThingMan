import React, { FC, useState } from "react";
import {
  alpha,
  AppBar,
  Box,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
} from "@mui/material";
import { styled } from "@mui/material/styles";
import { AccountCircle, Menu as MenuIcon } from "@mui/icons-material";

import { useAuth } from "../../hooks";

const PREFIX = "top-section";
const classes = {
  appBar: `${PREFIX}-appBar`,
  title: `${PREFIX}-title`,
  menuButton: `${PREFIX}-menuButton`,
};

const Root = styled("div")(({ theme }) => {
  const drawerWidth = 240;
  return {
    [`& .${classes.appBar}`]: {
      [theme.breakpoints.up("sm")]: {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: drawerWidth,
      },
    },
    [`& .${classes.title}`]: {
      flexGrow: 1,
    },
    [`& .${classes.menuButton}`]: {
      marginRight: theme.spacing(2),
      [theme.breakpoints.up("sm")]: {
        display: "none",
      },
    },
  };
});

interface Props {
  onDrawerToggle: () => void;
}

const TopSection: FC<Props> = ({ onDrawerToggle }: Props) => {
  const { signOut } = useAuth();

  const [anchorEl, setAnchorEl] = useState<HTMLButtonElement | null>(null);
  const handleOpenMenu = (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ): void => {
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMenu = () => {
    setAnchorEl(null);
  };

  return (
    <Root>
      <AppBar elevation={1} className={classes.appBar}>
        <Toolbar>
          <IconButton className={classes.menuButton} onClick={onDrawerToggle}>
            <MenuIcon />
          </IconButton>
          <Box className={classes.title} />
          <IconButton color="default" onClick={handleOpenMenu}>
            <AccountCircle />
          </IconButton>
          <Menu
            anchorEl={anchorEl}
            keepMounted
            open={Boolean(anchorEl)}
            onClose={handleCloseMenu}
          >
            <MenuItem onClick={() => signOut()}>Sign Out</MenuItem>
          </Menu>
        </Toolbar>
      </AppBar>
    </Root>
  );
};

export default TopSection;
