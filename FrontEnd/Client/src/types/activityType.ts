
import z from 'zod';

export const activityObject = z.object({
    id: z.string(),
    title: z.string(),
    description: z.string(),
    category: z.string(),
    eventDate: z.string(),
    city: z.string(),
    venue: z.string(),
    latitude: z.number().min(-90).max(90),
    longitude: z.number().min(-180).max(180),
    isCancelled: z.boolean().default(false)
});

export type Activity = z.infer<typeof activityObject>;