#include "InGameRenderer.h"
#include "Helpers/Renderer.h"
#include "Helpers/Maths.h"
#include "Game.h"
#include "Hooking/Hooks.h"

//================================//Debug API//================================//

void InGameRenderer::DrawLine2D(const Vector2& start, const Vector2& end, D3DCOLOR color)
{
	VertexData2D startData
	{
		start.x,
		start.y,
		0.0f,
		1.0f,
		color

	};
	lines2D.push_back(startData);

	VertexData2D endData
	{
		end.x,
		end.y,
		0.0f,
		1.0f,
		color

	};
	lines2D.push_back(endData);
}

void InGameRenderer::DrawInvertedShape2D(const Vector2& centre, const Vector2& innerSize, const Vector2& size, int sides, float radius, D3DCOLOR color)
{
	// Draw quarter shape for each corner
	int qSides = sides / 4;
	const float increment = -6.28318530718f / sides;
	constexpr float quarterCircle = 3.14159265359f / 2;

	VertexData2D vertex{
		0.0f,
		0.0f,
		0.0f,
		1.0f,
		color
	};

	auto DrawQuadrantInner = [&](Polygon2D& polygon, Vector2 quadCentre, float offset = 0.0f)
		{
			for (int i = 0; i <= qSides; i++)
			{
				float angle = increment * i - offset;
				Vector2 newPoint = quadCentre + Vector2(sin(angle), -cos(angle)) * radius;

				vertex.x = newPoint.x;
				vertex.y = newPoint.y;
				polygon.vertices.push_back(vertex);
			}
		};

	auto DrawQuadrant = [&](Vector2 corner, Vector2 quadCentre, Vector2 startEdge, Vector2 endEdge, int i)
		{
			Polygon2D polygon;
			// Corner vertex
			vertex.x = corner.x;
			vertex.y = corner.y;
			polygon.vertices.push_back(vertex);
			// Vertex on edge, near quadrant start
			vertex.x = startEdge.x;
			vertex.y = startEdge.y;
			polygon.vertices.push_back(vertex);

			// Quadrant
			DrawQuadrantInner(polygon, quadCentre, quarterCircle * i);

			// Vertex on edge, near quadrant end
			vertex.x = endEdge.x;
			vertex.y = endEdge.y;
			polygon.vertices.push_back(vertex);

			// Submit quarter
			polygons2D.push_back(polygon);
		};

	auto DrawConnector = [&](Vector2 topLeft, Vector2 bottomRight)
		{
			Polygon2D polygon;

			vertex.x = topLeft.x;
			vertex.y = topLeft.y;
			polygon.vertices.push_back(vertex);

			vertex.x = bottomRight.x;
			vertex.y = topLeft.y;
			polygon.vertices.push_back(vertex);

			vertex.x = bottomRight.x;
			vertex.y = bottomRight.y;
			polygon.vertices.push_back(vertex);

			vertex.x = topLeft.x;
			vertex.y = bottomRight.y;
			polygon.vertices.push_back(vertex);

			polygons2D.push_back(polygon);
		};

	Vector2 tempCentre = centre;
	Vector2 halfInner = innerSize / 2;
	Vector2 topLeft, bottomRight;

	tempCentre = centre + Vector2(-halfInner.x, -halfInner.y);
	bottomRight = Vector2(tempCentre.x, 0.0f);
	DrawQuadrant(Vector2(0.0f, 0.0f), tempCentre, Vector2(tempCentre.x, 0.0f), Vector2(0.0f, tempCentre.y), 0);
	topLeft = Vector2(0.0f, tempCentre.y);

	tempCentre = centre + Vector2(-halfInner.x, +halfInner.y);
	DrawConnector(topLeft, Vector2(tempCentre.x - radius, tempCentre.y));
	topLeft = Vector2(tempCentre.x, tempCentre.y + radius);
	DrawQuadrant(Vector2(0.0f, size.y), tempCentre, Vector2(0.0f, tempCentre.y), Vector2(tempCentre.x, size.y), 1);

	tempCentre = centre + Vector2(+halfInner.x, +halfInner.y);
	DrawConnector(topLeft, Vector2(tempCentre.x, size.y));
	topLeft = Vector2(size.x, tempCentre.y);
	DrawQuadrant(size, tempCentre, Vector2(tempCentre.x, size.y), Vector2(size.x, tempCentre.y), 2);

	tempCentre = centre + Vector2(+halfInner.x, -halfInner.y);
	DrawQuadrant(Vector2(size.x, 0.0f), tempCentre, Vector2(size.x, tempCentre.y), Vector2(tempCentre.x, 0.0f), 3);
	DrawConnector(topLeft, Vector2(tempCentre.x + radius, tempCentre.y));
	DrawConnector(Vector2(tempCentre.x, tempCentre.y - radius), bottomRight);
}

void InGameRenderer::DrawLine3D(const Vector3& start, const Vector3& end, D3DCOLOR color, bool bRespectDepth, float thickness)
{
	VertexData3D startData
	{
		start.x,
		start.y,
		start.z,
		color
	};

	if (bRespectDepth)
	{
		depthLines3D.push_back(startData);
	}
	else
	{
		lines3D.push_back(startData);
	}

	VertexData3D endData
	{
		end.x,
		end.y,
		end.z,
		color
	};

	if (bRespectDepth)
	{
		depthLines3D.push_back(endData);
	}
	else
	{
		lines3D.push_back(endData);
	}
}

void InGameRenderer::DrawPolygon(const Vector3& centre, const Vector3& facing, const Vector3& upVector, int sides, float radius, D3DCOLOR color, bool bRespectDepth, float angleAmount)
{
	Polygon newPoly;

	VertexData3D vertex{};

	int alpha = ((color >> 24) & 255);

	if (alpha == 0)
	{
		color |= D3DCOLOR_ARGB(255, 0, 0, 0);
		newPoly.bIsStencil = true;
	}

	vertex.color = color;
	vertex.x = centre.x;
	vertex.y = centre.y;
	vertex.z = centre.z;

	newPoly.vertices.push_back(vertex);

	const Vector3 rightVector = facing.cross(upVector);

	Vector3 firstPoint = centre + upVector * radius;

	vertex.x = firstPoint.x;
	vertex.y = firstPoint.y;
	vertex.z = firstPoint.z;
	newPoly.vertices.push_back(vertex);

	const float increment = angleAmount * -6.28318530718f / sides;

	for (int i = 1; i < sides; i++)
	{
		float angle = increment * i;
		Vector3 newPoint = centre + (sin(angle) * rightVector + cos(angle) * upVector) * radius;

		vertex.x = newPoint.x;
		vertex.y = newPoint.y;
		vertex.z = newPoint.z;
		newPoly.vertices.push_back(vertex);
	}

	if ((1.0f - angleAmount) < 1e-8f)
	{
		vertex.x = firstPoint.x;
		vertex.y = firstPoint.y;
		vertex.z = firstPoint.z;
		newPoly.vertices.push_back(vertex);
	}
	else
	{
		float angle = increment * sides;
		Vector3 newPoint = centre + (sin(angle) * rightVector + cos(angle) * upVector) * radius;

		vertex.x = newPoint.x;
		vertex.y = newPoint.y;
		vertex.z = newPoint.z;
		newPoly.vertices.push_back(vertex);
	}

	if (bRespectDepth)
	{
		depthPolygons.push_back(newPoly);
	}
	else
	{
		polygons.push_back(newPoly);
	}
}

void InGameRenderer::DrawCoordinate(const Vector3& pos, const Matrix3& rot, float size, bool bRespectDepth)
{
	Vector3 up = pos + rot * Vector3(0.0f, 0.0f, size);
	Vector3 forward = pos + rot * Vector3(0.0f, size, 0.0f);
	Vector3 left = pos + rot * Vector3(size, 0.0f, 0.0f);

	DrawLine3D(pos, up, D3DCOLOR_XRGB(0, 0, 255), bRespectDepth, 0.01f);
	DrawLine3D(pos, forward, D3DCOLOR_XRGB(0, 255, 0), bRespectDepth, 0.01f);
	DrawLine3D(pos, left, D3DCOLOR_XRGB(255, 0, 0), bRespectDepth, 0.01f);
}

void InGameRenderer::DrawRenderTarget(IDirect3DTexture9* renderTarget, const Vector3& pos, const Matrix3& rot, const Vector2& size, bool bRespectDepth, bool bRespectStencil)
{
	RenderTarget rtData
	{
		pos,
		rot,
		size * 0.5f,
		renderTarget,
		bRespectDepth,
		bRespectStencil
	};

	renderTargets.push_back(rtData);
}

//================================//Core Functions//================================//

void InGameRenderer::ExtractMatrices(Renderer* playerRenderer)
{
	CameraRenderMatrices& cameraMatrices = *Helpers::GetActiveCameraMatrices();
	Game::instance.SetViewportScale(&cameraMatrices.viewport);

	Hooks::SetCameraMatrices(&cameraMatrices.viewport, &playerRenderer->frustum, &cameraMatrices, true);


	view._11 = cameraMatrices.viewMatrix.rotation[0];
	view._12 = cameraMatrices.viewMatrix.rotation[1];
	view._13 = cameraMatrices.viewMatrix.rotation[2];
	view._14 = 0.0;
	view._21 = cameraMatrices.viewMatrix.rotation[3];
	view._22 = cameraMatrices.viewMatrix.rotation[4];
	view._23 = cameraMatrices.viewMatrix.rotation[5];
	view._24 = 0.0;
	view._31 = cameraMatrices.viewMatrix.rotation[6];
	view._32 = cameraMatrices.viewMatrix.rotation[7];
	view._33 = cameraMatrices.viewMatrix.rotation[8];
	view._34 = 0.0;
	view._41 = cameraMatrices.viewMatrix.translation.x;
	view._43 = cameraMatrices.viewMatrix.translation.z;
	view._42 = cameraMatrices.viewMatrix.translation.y;
	view._44 = 1.0;
	world._43 = 0.0;
	world._42 = 0.0;
	world._41 = 0.0;
	world._34 = 0.0;
	world._32 = 0.0;
	world._31 = 0.0;
	world._24 = 0.0;
	world._23 = 0.0;
	world._21 = 0.0;
	world._14 = 0.0;
	world._13 = 0.0;
	world._12 = 0.0;
	world._44 = 1.0;
	world._33 = 1.0;
	world._22 = 1.0;
	world._11 = 1.0;
	projection = cameraMatrices.projectionMatrix;

	// Extract the near/far clipping planes then bring them in close to prevent clipping on scopes and such

	float nearZ = projection._43 / (projection._33 - 1.0f);

	float farZ = projection._43 / (projection._33 + 1.0f);

	float newNear = nearZ * 0.1f;
	float newFar = farZ * 0.1f;

	projection._33 = -(newFar + newNear) / (newFar - newNear);
	projection._43 = -(2.0f * newFar * newNear) / (newFar - newNear);
}

void InGameRenderer::Render(IDirect3DDevice9* pDevice)
{
	LPDIRECT3DSTATEBLOCK9 pStateBlock = NULL;
	pDevice->CreateStateBlock(D3DSBT_ALL, &pStateBlock);

	pDevice->Clear(0, NULL, D3DCLEAR_STENCIL, D3DCOLOR_XRGB(0, 0, 0), 0.0f, 0);

	Draw2DLines(pDevice);

	Draw2DPolygons(pDevice);

	Draw3DLines(pDevice);

	DrawPolygons(pDevice);

	DrawRenderTargets(pDevice);

	pStateBlock->Apply();
	pStateBlock->Release();
}

void InGameRenderer::PostRender()
{
	lines2D.clear();
	polygons2D.clear();
	lines3D.clear();
	depthLines3D.clear();
	renderTargets.clear();
	polygons.clear();
	depthPolygons.clear();
}

void InGameRenderer::ClearRenderTargets()
{
	renderTargets.clear();
}

//================================//Internal Functions//================================//

void InGameRenderer::Draw2DLines(IDirect3DDevice9* pDevice)
{
	pDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, true);
	pDevice->SetRenderState(D3DRS_DESTBLEND, D3DBLEND_INVSRCALPHA);
	pDevice->SetRenderState(D3DRS_LIGHTING, false);
	pDevice->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

	pDevice->DrawPrimitiveUP(D3DPT_LINELIST, vertex2DCount / 2, vertices2D, sizeof(VertexData2D));

}

void InGameRenderer::Draw2DPolygons(IDirect3DDevice9* pDevice)
{
	pDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, false);
	pDevice->SetRenderState(D3DRS_LIGHTING, false);
	pDevice->SetRenderState(D3DRS_ZENABLE, false);
	pDevice->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

	for (Polygon2D& polygon : polygons2D)
	{
		pDevice->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, polygon.vertices.size() - 2, polygon.vertices.data(), sizeof(VertexData2D));
	}
}

void InGameRenderer::Draw3DLines(IDirect3DDevice9* pDevice)
{
	if (lines3D.empty() && depthLines3D.empty())
	{
		return;
	}

	pDevice->SetRenderState(D3DRS_ZENABLE, true);
	pDevice->SetFVF(D3DFVF_XYZ | D3DFVF_DIFFUSE);
	pDevice->SetTransform(D3DTS_WORLD, &world);
	pDevice->SetTransform(D3DTS_VIEW, &view);
	pDevice->SetTransform(D3DTS_PROJECTION, &projection);

	pDevice->DrawPrimitiveUP(D3DPT_LINELIST, depthLines3D.size() / 2, depthLines3D.data(), sizeof(VertexData3D));
	pDevice->SetRenderState(D3DRS_ZENABLE, false);
	pDevice->DrawPrimitiveUP(D3DPT_LINELIST, lines3D.size() / 2, lines3D.data(), sizeof(VertexData3D));
}

void InGameRenderer::DrawRenderTargets(IDirect3DDevice9* pDevice)
{
	// Normal blending, assumes texture actually has an alpha value
	//*
	pDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, TRUE);
	pDevice->SetRenderState(D3DRS_BLENDOP, D3DBLENDOP_ADD);
	pDevice->SetRenderState(D3DRS_SRCBLEND, D3DBLEND_ONE); // Intercepted UI layers are premultiplied
	pDevice->SetRenderState(D3DRS_DESTBLEND, D3DBLEND_INVSRCALPHA);
	//*/

	// Greyscale alpha
	/*
	pDevice->SetRenderState(D3DRS_BLENDOP, D3DBLENDOP_ADD);
	pDevice->SetRenderState(D3DRS_SRCBLEND, D3DBLEND_ONE);
	pDevice->SetRenderState(D3DRS_DESTBLEND, D3DBLEND_ZERO);

	pDevice->SetTextureStageState(0, D3DTSS_COLOROP, D3DTOP_SELECTARG1);
	pDevice->SetTextureStageState(0, D3DTSS_COLORARG1, D3DTA_TEXTURE | D3DTA_ALPHAREPLICATE);

	// Disable further stages
	pDevice->SetTextureStageState(1, D3DTSS_COLOROP, D3DTOP_DISABLE);
	//*/

	pDevice->SetFVF(D3DFVF_XYZ | D3DFVF_TEX1);
	pDevice->SetTransform(D3DTS_WORLD, &world);
	pDevice->SetTransform(D3DTS_VIEW, &view);
	pDevice->SetTransform(D3DTS_PROJECTION, &projection);


	pDevice->SetRenderState(D3DRS_STENCILREF, 1);
	pDevice->SetRenderState(D3DRS_STENCILFUNC, D3DCMP_EQUAL);
	pDevice->SetRenderState(D3DRS_STENCILPASS, D3DSTENCILOP_KEEP);
	pDevice->SetRenderState(D3DRS_STENCILFAIL, D3DSTENCILOP_KEEP);
	pDevice->SetRenderState(D3DRS_STENCILZFAIL, D3DSTENCILOP_KEEP);

	static WORD indices[] = {
		0, 1, 3, 2, 3, 1
	};

	pDevice->SetRenderState(D3DRS_STENCILENABLE, 1);

	for (size_t i = 0; i < renderTargets.size(); i++)
	{
		Vector3 centre = renderTargets[i].pos;
		Vector3 sizeTR = renderTargets[i].rot * Vector3(renderTargets[i].size.x, 0.0f, renderTargets[i].size.y);
		Vector3 sizeBR = renderTargets[i].rot * Vector3(renderTargets[i].size.x, 0.0f, -renderTargets[i].size.y);
		Vector3 sizeBL = renderTargets[i].rot * Vector3(-renderTargets[i].size.x, 0.0f, -renderTargets[i].size.y);
		Vector3 sizeTL = renderTargets[i].rot * Vector3(-renderTargets[i].size.x, 0.0f, renderTargets[i].size.y);

		VertexDataTex vertices[] = {
			{centre.x + sizeTR.x, centre.y + sizeTR.y, centre.z + sizeTR.z, 1.0f, 0.0f},
			{centre.x + sizeBR.x, centre.y + sizeBR.y, centre.z + sizeBR.z, 1.0f, 1.0f},
			{centre.x + sizeBL.x, centre.y + sizeBL.y, centre.z + sizeBL.z, 0.0f, 1.0f},
			{centre.x + sizeTL.x, centre.y + sizeTL.y, centre.z + sizeTL.z, 0.0f, 0.0f}
		};

		pDevice->SetRenderState(D3DRS_ZENABLE, renderTargets[i].bRespectDepth);

		pDevice->SetRenderState(D3DRS_STENCILFUNC, renderTargets[i].bRespectStencil ? D3DCMP_EQUAL : D3DCMP_NOTEQUAL);

		pDevice->SetTexture(0, renderTargets[i].texture);

		pDevice->DrawIndexedPrimitiveUP(D3DPT_TRIANGLELIST, 0, 4, 2, indices, D3DFMT_INDEX16, vertices, sizeof(VertexDataTex));

		//WinlatorXR Change
		pDevice->SetRenderState(D3DRS_LIGHTING, false);
		pDevice->SetRenderState(D3DRS_ZENABLE, false);

		pDevice->SetTextureStageState(0, D3DTSS_COLOROP, D3DTOP_SELECTARG1);
		pDevice->SetTextureStageState(0, D3DTSS_COLORARG1, D3DTA_DIFFUSE);

		pDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, TRUE);

		pDevice->SetRenderState(D3DRS_SRGBWRITEENABLE, TRUE);

		pDevice->SetTexture(0, renderTargets[i].texture);
		pDevice->SetFVF(D3DFVF_XYZRHW | D3DFVF_DIFFUSE);

		VertexData2D oxrVerts[4] = {
			{ 0.0f,   0.0f, 0.0f, 1.0f, D3DCOLOR_ARGB(255,255, 0, 0) }, // Top-left
			{ 10.0f,  0.0f, 0.0f, 1.0f, D3DCOLOR_ARGB(255,255, 0, 0) }, // Top-right
			{ 10.0f, 10.0f, 0.0f, 1.0f, D3DCOLOR_ARGB(255,255, 0, 0) }, // Bottom-right
			{ 0.0f,  10.0f, 0.0f, 1.0f, D3DCOLOR_ARGB(255,255, 0, 0) }  // Bottom-left
		};

		// Draw the rectangle using DrawPrimitiveUP
		pDevice->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, 2, oxrVerts, sizeof(VertexData2D));
	}
}

void InGameRenderer::DrawPolygons(IDirect3DDevice9* pDevice)
{
	if (polygons.empty() && depthPolygons.empty())
	{
		return;
	}

	pDevice->SetRenderState(D3DRS_ZENABLE, true);
	pDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, true);
	pDevice->SetFVF(D3DFVF_XYZ | D3DFVF_DIFFUSE);
	pDevice->SetTransform(D3DTS_WORLD, &world);
	pDevice->SetTransform(D3DTS_VIEW, &view);
	pDevice->SetTransform(D3DTS_PROJECTION, &projection);

	for (Polygon polygon : depthPolygons)
	{
		pDevice->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, polygon.vertices.size() - 2, polygon.vertices.data(), sizeof(VertexData3D));
	}
	pDevice->SetRenderState(D3DRS_ZENABLE, false);

	pDevice->SetRenderState(D3DRS_STENCILREF, 1);
	pDevice->SetRenderState(D3DRS_STENCILFUNC, D3DCMP_ALWAYS);
	pDevice->SetRenderState(D3DRS_STENCILMASK, 0xFFFFFFFF);
	pDevice->SetRenderState(D3DRS_STENCILWRITEMASK, 0XFFFFFFFF);
	pDevice->SetRenderState(D3DRS_STENCILFAIL, D3DSTENCILOP_KEEP);
	pDevice->SetRenderState(D3DRS_STENCILZFAIL, D3DSTENCILOP_KEEP);
	pDevice->SetRenderState(D3DRS_STENCILPASS, D3DSTENCILOP_REPLACE);

	for (Polygon polygon : polygons)
	{

		pDevice->SetRenderState(D3DRS_STENCILENABLE, polygon.bIsStencil);

		pDevice->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, polygon.vertices.size() - 2, polygon.vertices.data(), sizeof(VertexData3D));
	}
}
