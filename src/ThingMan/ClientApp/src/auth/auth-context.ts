import { createContext } from "react";

import { ClaimDto } from "../api/dtos";

interface Props {
  loading: boolean;
  signedIn: boolean;
  claims: ClaimDto[];
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
