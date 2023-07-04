import { createContext } from "react";

import { Claim } from "../api/models";

interface Props {
  loading: boolean;
  signedIn: boolean;
  claims: Claim[];
  signIn: (username: string, password: string) => Promise<void>;
  signOut: () => Promise<void>;
  error: string | null;
}

const defaultValue: Props = {
  loading: false,
  signedIn: false,
  claims: [],
  signIn: async () => {},
  signOut: async () => {},
  error: null,
};

const AuthContext = createContext<Props>(defaultValue);

export default AuthContext;
