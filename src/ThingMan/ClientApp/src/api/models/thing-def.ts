import { PropDef } from "./prop-def";
import { StatusDef } from "./status-def";

export interface ThingDef {
  id: string | null;
  userId: string;
  name: string;
  statusDefs: StatusDef[];
  propDef1: PropDef | null;
  propDef2: PropDef | null;
  propDef3: PropDef | null;
  propDef4: PropDef | null;
  propDef5: PropDef | null;
}
