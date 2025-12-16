import { useQuery, useQueryClient } from "@tanstack/react-query";
import { getAllActivities } from "../library/activityApis";
import { useIsLoading } from "./appContextHooks";


export default function useActivities() {
    const queryClient = useQueryClient();
    const { setLoader } = useIsLoading();

    const { data: activities, isLoading: isLoadingActivities } = useQuery({
        queryKey: ["activities"],
        queryFn: async () => {
            setLoader(true);
            try {
                return await getAllActivities();
            }
            finally {
                setLoader(false);
            }
        },
        enabled: true,
        staleTime: 5 * 1000 * 60
    });

    return { activities, isLoadingActivities };
}