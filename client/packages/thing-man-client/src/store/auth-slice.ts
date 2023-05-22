import { createSlice } from "@reduxjs/toolkit";

export interface AuthState {
  name: string | null;
  exp: number | null;
  logoutUrl: string | null;
}

const initialState: AuthState = {
  name: null,
  exp: null,
  logoutUrl: null,
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    setAuth: (state, action) => {
      state.name = action.payload.name;
      state.exp = action.payload.exp;
      state.logoutUrl = action.payload.logoutUrl;
    },
  },
});

export default authSlice;
