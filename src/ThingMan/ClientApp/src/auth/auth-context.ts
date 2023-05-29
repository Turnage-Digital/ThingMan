import { createContext, useContext } from "react";

interface Props {
  isLoggedIn: boolean;
  login?: () => void;
  logout?: () => void;
}

const AuthContext = createContext<Props>({ isLoggedIn: false });

export default AuthContext;
