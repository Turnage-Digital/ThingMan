import { createTheme } from "@mui/material";

const rootElement = document.getElementById("root");
const theme = createTheme({
  palette: {
    primary: {
      main: "#0c95bf",
    },
    secondary: {
      main: "#0c95bf",
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
