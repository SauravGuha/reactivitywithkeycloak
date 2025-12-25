import { useQuery } from "@tanstack/react-query";
import { getUserInfo } from "../library/userApi";
import { useIsLoading } from "./appContextHooks";

export default function useUsers() {
    const { setLoader } = useIsLoading();

    const { data: userInfo, isPending: isFetchingUserInfo } = useQuery({
        queryKey: ["userinfo"],
        queryFn: async () => {
            setLoader(true);
            try {
                return getUserInfo();
            }
            finally {
                setLoader(false);
            }
        },
        retry: 1,
        staleTime: 5 * 1000 * 60
    });

    return { userInfo, isFetchingUserInfo };
}
