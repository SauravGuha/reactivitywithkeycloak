import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getAllActivities, getById, updateActivity } from "../library/activityApis";
import { useIsLoading } from "./appContextHooks";
import type { Activity } from "../types/activityType";


export default function useActivities(id?: string) {
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
        enabled: id ? false : true,
        staleTime: 5 * 1000 * 60
    });

    const { data: activity, isLoading: isLoadingActivity } = useQuery({
        queryKey: ["activity", id],
        queryFn: async () => {
            setLoader(true);
            try {
                return await getById(id!);
            }
            finally {
                setLoader(false);
            }
        },
        enabled: id ? true : false,
        staleTime: 5 * 1000 * 60
    });

    const { mutate: update, isPending: isUpdating } = useMutation({
        mutationFn: async (data: Activity) => {
            setLoader(true);
            try {
                return await updateActivity(data.id, data);
            }
            finally {
                setLoader(false);
            }
        },
        onSuccess: (data: Activity) => {
            queryClient.removeQueries({ queryKey: ["activities"] });
            queryClient.removeQueries({ queryKey: ["activity", data.id] })
        }
    });

    return { activities, isLoadingActivities, activity, isLoadingActivity, update, isUpdating };
}