import Head from 'next/head'
import Image from 'next/image'
import { Inter } from 'next/font/google'
import styles from '@components/styles/Home.module.css'
import CrudButton from '../components/CrudButton/CrudButton'
import { getStaticProps } from '../pages/api/hello'
import { useState, useEffect } from 'react'
import ValueList from '@components/components/ValueList/ValueList'
import { Button, Space, Input, Form } from 'antd'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  const [input, setInput] = useState('')
  const [content, setContent] = useState('')
  const [valueList, setValueList] = useState([])

  useEffect(() => {
    getAll()
  }, [])

  const handleInput = (event: any) => {
    setInput(event.target.value)
    console.log(input)
  }
  const handleContent = (event: any) => {
    setContent(event.target.value)
    console.log(content)
  }

  const getAll = async () => {
    const res = await fetch('https://localhost:7056/api/Values', {    
      method: 'GET',   
      mode: 'cors', 
      headers: {
        'Content-Type': 'application/json'
        },
        
    });
    const data = await res.json()
    setValueList(data)
  }

  const getById = async () => {
    const res = await fetch('https://localhost:7056/api/Values/' + input, {    
      method: 'GET',   
      mode: 'cors', 
      headers: {
        'Content-Type': 'application/json'
        },
        
    });
    const data = await res.json()
    setValueList(data)
  }

  const Delete = async () => {
    const res = await fetch('https://localhost:7056/api/Values/' + input, {    
      method: 'DELETE',   
      mode: 'cors', 
      headers: {
        'Content-Type': 'application/json'
        },
    });
    getAll()
  }
  const Add = async () => {
    const res = await fetch('https://localhost:7056/api/Values?value=' + content, {    
      method: 'POST',   
      mode: 'cors', 
      headers: {
        'Content-Type': 'application/json'
        },
    });
    getAll()
  }

  const Modify = async () => {
    const res = await fetch('https://localhost:7056/api/Values/' + input + '?value=' + content, {    
      method: 'PUT',   
      mode: 'cors', 
      headers: {
        'Content-Type': 'application/json'
        },
    });
    getAll()
  }
  
  return (
    <>
      <Head>
        <title>Next App</title>
        <meta name="description" content="Generated by create next app" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <main className={styles.main}>
        

        <Space direction="vertical" className={styles.center}>
          <Space wrap>
            <Button type="primary" onClick={getAll}>Get All</Button>
            <Button type="primary" onClick={getById}>Get By Id</Button>
            <Button type="primary" onClick={Add}>Add</Button>
            <Button type="primary" onClick={Modify}>Modify</Button>
            <Button type="primary" danger onClick={Delete}>Delete</Button>
          </Space>
          <Form.Item label="ID:" style={{ maxHeight: 12 }}>
            <Input placeholder="Enter the ID" value={input} onChange={handleInput} style={{ marginLeft: 34, maxWidth: 336}} />
          </Form.Item>
          <Form.Item label="Content:" style={{ maxHeight: 12 }}>
            <Input placeholder="Enter the Content" value={content} onChange={handleContent}/>
          </Form.Item>
          {valueList != null && <ValueList data={valueList}/>}
        </Space>
      </main>
    </>
  )
}
