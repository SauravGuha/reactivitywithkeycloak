import { useEffect, useRef, useState } from "react"
import Keycloak from "keycloak-js";

export const keycloakClient = new Keycloak({
    url: import.meta.env.VITE_KEYCLOAKURL,
    realm: import.meta.env.VITE_REALM,
    clientId: import.meta.env.VITE_CLIENT
});

export const useAuth = () => {
    const [islogin, setLogin] = useState(false);
    const isRuning = useRef(false);

    useEffect(() => {
        if (isRuning.current)
            return;

        isRuning.current = true;


        keycloakClient.init({
            onLoad: "login-required",
            pkceMethod: "S256",
            checkLoginIframe: false,
        })
            .then(response => setLogin(response));
    }, []);

    return islogin;
}