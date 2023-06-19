import { NotificationDefDto } from "./notification-def-dto";
import { PropDefDto } from "./prop-def-dto";
import { StatusDefDto } from "./status-def-dto";

export interface ThingDefDto {
  id: string | null;
  userId: string;
  name: string;
  statusDefs: StatusDefDto[];
  notificationDefs: NotificationDefDto[];
  propDef1: PropDefDto | null;
  propDef2: PropDefDto | null;
  propDef3: PropDefDto | null;
  propDef4: PropDefDto | null;
  propDef5: PropDefDto | null;
}
