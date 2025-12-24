import { createContext, useContext } from "react";

const LoadingContext = createContext<{ isLoading: boolean, setLoader: (value: boolean) => void } | undefined>(undefined);

function useIsLoading() {
    const lc = useContext(LoadingContext);
    if (lc) {
        return lc;
    }
    else {
        throw new Error("LoadingContext is not set");
    }
}

const IsAuthenticated = createContext<boolean>(false);

function useIsAuthenticated() {
    const lc = useContext(IsAuthenticated);
    if (lc) {
        return lc;
    }
    else {
        return false;
    }
}

export { LoadingContext, useIsLoading, IsAuthenticated, useIsAuthenticated }