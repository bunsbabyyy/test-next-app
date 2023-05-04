import React, { FC } from 'react';
import { ValueListWrapper, ValueTable } from './ValueList.styled';
import { Table } from 'antd';
import type { ColumnsType } from 'antd/es/table';

type ValueListProps = {
	data: any
}

type Value = {
	Id: number,
	Content: string,
}

const columns: ColumnsType<Value> = [
  {
    title: 'Id',
    dataIndex: 'Id',
  },
  {
    title: 'Content',
    dataIndex: 'Content',
  },
];

const ValueList: FC<ValueListProps> = ({data}) => (
	
  <ValueListWrapper>
		<Table columns={columns} dataSource={data} size="small" bordered/>
   {/* <ValueTable>
		<tr>
			<th>Id</th>
			<th>Content</th>
		</tr>
			{data.map((value: Value) => (
				<tr>
					<td>{value.Id}</td>
					<td>{value.Content}</td>
				</tr>
			))}
   </ValueTable> */}
  </ValueListWrapper>
);

export default ValueList;
