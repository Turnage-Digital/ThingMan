import { createSlice } from "@reduxjs/toolkit";

export interface ShellState {
  loading: boolean;
  alert: {
    message: string | null;
    severity: "success" | "error" | undefined;
  } | null;
}

const initialState: ShellState = {
  loading: false,
  alert: null,
};

const shellSlice = createSlice({
  name: "shell",
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.alert = { message: action.payload, severity: "error" };
    },
    setInfo: (state, action) => {
      state.alert = { message: action.payload, severity: "success" };
    },
    setAlert: (state, action) => {
      state.alert = action.payload;
    },
  },
});

export default shellSlice;
