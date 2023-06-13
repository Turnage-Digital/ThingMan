import { ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import React, { FC, ReactElement } from "react";
import { Link, LinkProps } from "react-router-dom";

interface Props {
  to: string;
  primary: string;
  icon: ReactElement;
  selected: boolean;
  onClick: () => void;
}

const RouterListItem: FC<Props> = ({
  to,
  primary,
  icon,
  selected,
  onClick,
}: Props) => {
  // eslint-disable-next-line react/display-name
  const forwardRef = React.forwardRef<
    HTMLAnchorElement,
    Omit<LinkProps, "innerRef" | "to">
  >((props, ref) => <Link ref={ref} to={to} {...props} />);
  return (
    <ListItemButton
      component={forwardRef}
      selected={selected}
      onClick={() => onClick()}
    >
      <ListItemIcon>{icon}</ListItemIcon>
      <ListItemText primary={primary} />
    </ListItemButton>
  );
};

export default RouterListItem;
