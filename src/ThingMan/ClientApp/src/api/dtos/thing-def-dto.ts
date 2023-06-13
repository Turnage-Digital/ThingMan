import { PropDefDto } from "./prop-def-dto";
import { StatusDefDto } from "./status-def-dto";

export interface ThingDefDto {
  name: string;
  userId: string;
  statusDefs: StatusDefDto[];
  propDef1: PropDefDto | null;
  propDef2: PropDefDto | null;
  propDef3: PropDefDto | null;
  id: string | null;
}
