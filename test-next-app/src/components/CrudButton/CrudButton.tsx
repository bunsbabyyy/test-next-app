import React, { FC } from 'react';
import { CrudButtonWrapper, Button } from './CrudButton.styled';

type CrudButtonProps = {
	label: string
}

const CrudButton: FC<CrudButtonProps> = ({label}) => (
	<CrudButtonWrapper>
		<Button className="btn" type="submit">{label}</Button>
	</CrudButtonWrapper>
);

export default CrudButton;