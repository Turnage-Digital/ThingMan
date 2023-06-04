import React, { FC } from "react";
import { styled } from "@mui/material/styles";

const PREFIX = "content-section";
const classes = {
  drawerHeader: `${PREFIX}-drawerHeader`,
  content: `${PREFIX}-content`,
};
const Root = styled("div")(({ theme }) => ({
  [`& .${classes.drawerHeader}`]: {
    ...theme.mixins.toolbar,
  },
  [`& .${classes.content}`]: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
}));

type Props = React.PropsWithChildren;

const ContentSection: FC<Props> = ({ children }: Props) => {
  return (
    <Root>
      <div className={classes.content}>
        <div className={classes.drawerHeader} />
        {children}
      </div>
    </Root>
  );
};

export default ContentSection;
