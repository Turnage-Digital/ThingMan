import { createTheme } from "@mui/material";

const rootElement = document.getElementById("root");
const theme = createTheme({
  palette: {
    mode: "dark",
    primary: {
      main: "#BF360C",
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
