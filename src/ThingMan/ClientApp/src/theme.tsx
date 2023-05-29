import { createTheme } from "@mui/material";

const rootElement = document.getElementById("root");
const theme = createTheme({
  palette: {
    primary: {
      main: "#1e88e5",
    },
    secondary: {
      main: "#ff9800",
    },
  },
  components: {
    MuiPopover: {
      defaultProps: {
        container: rootElement,
      },
    },
    MuiPopper: {
      defaultProps: {
        container: rootElement,
      },
    },
  },
});

export default theme;
